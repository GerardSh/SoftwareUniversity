using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        IRepository<ISubject> subjects;
        IRepository<IStudent> students;
        IRepository<IUniversity> universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;

            IStudent student = students.FindByName(fullName);

            if (student != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            int id = students.Models.Count + 1;

            students.AddModel(new Student(id, firstName, lastName));

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = null;
            int id = subjects.Models.Count + 1;

            if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(id, subjectName);
            }
            else if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(id, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(id, subjectName);
            }
            else
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            subjects.AddModel(subject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = null;

            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> subjectIds = new List<int>();

            foreach (var subject in requiredSubjects)
            {
                subjectIds.Add(subjects.FindByName(subject).Id);
            }

            int id = universities.Models.Count + 1;

            university = new University(id, universityName, category, capacity, subjectIds);

            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split()[0];
            string lastName = studentName.Split()[1];

            IStudent student = students.FindByName(studentName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            IUniversity university = universities.FindByName(universityName);

            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            foreach (var subject in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Any(x => x == subject))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if (student.University?.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);

            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            ISubject subject = subjects.FindById(subjectId);

            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            if (student.CoveredExams.Any(x => x == subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            var sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");

            int studentsCount = students.Models.Count(x => x.University?.Name == university.Name);

            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.Append($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString();
        }
    }
}