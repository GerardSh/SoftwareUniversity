namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Utilities;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > DateTime.Parse(date)))
                .Select(p => new ExportPatientDto
                {
                    Gender = p.Gender.ToString().ToLower(),
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines
                        .Select(pm => pm.Medicine)
                        .Where(m=> m.ProductionDate > DateTime.Parse(date))
                        .OrderByDescending(m => m.ExpiryDate)
                        .ThenBy(m => m.Price)
                        .Select(m => new ExportMedicineDto
                        {
                            Name = m.Name,
                            Price = m.Price.ToString("f2"),
                            BestBefore = m.ExpiryDate.ToString("yyyy-MM-dd"),
                            Category = m.Category.ToString().ToLower(),
                            Producer = m.Producer,
                        })
                        .ToList()
                })
                .OrderByDescending(p => p.Medicines.Count)
                .ThenBy(p => p.Name)
                .ToList();

            var result = XmlHelper.Serialize(patients, "Patients");

            return result;
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m => m.Pharmacy.IsNonStop && (int)m.Category == medicineCategory)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    m.Name,
                    Price = m.Price.ToString("f2"),
                    Pharmacy = new
                    {
                        m.Pharmacy.Name,
                        m.Pharmacy.PhoneNumber
                    }
                })
                .ToList();

            var result = JsonConvert.SerializeObject(medicines, Formatting.Indented);

            return result;
        }
    }
}
