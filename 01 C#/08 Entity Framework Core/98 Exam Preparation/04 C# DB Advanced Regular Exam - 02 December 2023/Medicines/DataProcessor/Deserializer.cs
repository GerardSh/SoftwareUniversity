namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Microsoft.EntityFrameworkCore;
    using Medicines.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var output = new StringBuilder();

            var patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            if (patientDtos == null || patientDtos.Length < 1) return string.Empty;

            var validPatients = new List<Patient>();

            foreach (var patientDto in patientDtos)
            {
                bool isAgeGrpoupValid = Enum.TryParse(patientDto.AgeGroup, out AgeGroup ageGroup)
                    && Enum.IsDefined(typeof(AgeGroup), ageGroup);
                bool isGenderValid = Enum.TryParse(patientDto.Gender, out Gender gender)
                    && Enum.IsDefined(typeof(Gender), gender);

                if (!IsValid(patientDto) || !isAgeGrpoupValid || !isGenderValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var patient = new Patient()
                {
                    AgeGroup = ageGroup,
                    Gender = gender,
                    FullName = patientDto.FullName,         
                };

                if (patientDto.Medicines != null && patientDto.Medicines.Count > 0)
                {
                    foreach (var medicine in patientDto.Medicines)
                    {
                        if (patient.PatientsMedicines.Any(pc => pc.MedicineId == medicine))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (context.Medicines.Find(medicine) == null)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        var patientMedicine = new PatientMedicine()
                        {
                            MedicineId = medicine,
                            Patient = patient
                        };

                        patient.PatientsMedicines.Add(patientMedicine);
                    }
                }

                validPatients.Add(patient);
                output.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var output = new StringBuilder();

            var pharmacyDtos = XmlHelper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            if (pharmacyDtos == null || pharmacyDtos.Length < 1) return string.Empty;

            var validPharmacies = new List<Pharmacy>();

            foreach (var pharmacyDto in pharmacyDtos)
            {
                bool isBoolValid = bool.TryParse(pharmacyDto.NonStop, out bool boolValue);

                if (!IsValid(pharmacyDto) || !isBoolValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var currentPharmacyInDb = context.Pharmacies
                    .Where(p => p.Name == pharmacyDto.Name)
                    .Include(p => p.Medicines)
                    .FirstOrDefault();

                var validMedicines = new List<Medicine>();

                foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    bool isProdDateValid = DateTime.TryParseExact(medicineDto.ProductionDate,
                            "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime prodDate);
                    bool isExpDateValid = DateTime.TryParseExact(medicineDto.ExpiryDate,
                            "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate);
                    bool isCategoryValid = Enum.TryParse(medicineDto.Category, out Category category)
                       && Enum.IsDefined(typeof(Category), category);

                    if (!IsValid(medicineDto) || !isCategoryValid || !isProdDateValid || !isExpDateValid || prodDate >= expDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (currentPharmacyInDb != null && currentPharmacyInDb.Medicines != null)
                    {
                        if (currentPharmacyInDb.Medicines.Any(m => m.Producer == medicineDto.Producer && m.Name == medicineDto.Name))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    if (validMedicines.Any(m => m.Producer == medicineDto.Producer && m.Name == medicineDto.Name))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var medicine = new Medicine()
                    {
                        Name = medicineDto.Name,
                        Category = category,
                        ExpiryDate = expDate,
                        ProductionDate = prodDate,
                        Price = medicineDto.Price,
                        Producer = medicineDto.Producer
                    };

                    validMedicines.Add(medicine);
                }

                var pharmacy = new Pharmacy()
                {
                    IsNonStop = boolValue,
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    Medicines = validMedicines
                };

                validPharmacies.Add(pharmacy);
                output.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return output.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
