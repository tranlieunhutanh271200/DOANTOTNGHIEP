using Microsoft.EntityFrameworkCore;
using Service.Core.Models.Courses;
using Service.Core.Persistence;
using System;
using System.Collections.Generic;

namespace Course.gRPC.Persistence.Seeders
{
    public class CourseSeeder : BaseSeeder
    {
        public override void Seed(DbContext dbContext, Guid domainId, Guid accountId)
        {
            Semester semester = new Semester()
            {
                DomainId = domainId,
                SemesterName = "Học kỳ 1",
                SemesterStart = DateTime.Now,
                SemesterEnd = DateTime.Now.AddMonths(5),
                Year = DateTime.Now.Year
            };
            dbContext.Add(semester);
            Student student = new Student
            {
                AccountId = accountId,
                StudentID = "18110101",
                Fullname = "Trần Liễu Nhựt Anh",
                PermanentAddress = "TP.HCM",
                CurrentAddress = "TP.HCM",
                IdentityNo = "999999999999",
                BirthDate = DateTime.Parse("06-09-2000"),
                JoinDate = DateTime.Now
            };
            dbContext.Add(student);
            Teacher teacher = new Teacher
            {
                TeacherID = "IT100001",
                Fullname = "Lê Thị Minh Châu",
                IdentityNo = "888888888888",
                PermanentAddress = "TP.HCM",
                CurrentAddress = "TP.HCM",
            };
            dbContext.Add(teacher);
            Subject databaseManagementSystem = new Subject
            {
                Title = "Hệ quản trị CSDL",
                Credit = 3,
                PricePerCredit = 720000,
                TotalPeriod = 4,
                Description = "Môn hệ quản trị cơ sở dữ liệu",
                CoverImageUrl = "https://iweb.tatthanh.com.vn/pic/3/blog/he-quan-tri-co-so-du-lieu-pho-bien(1).png"
            };
            Subject programingBasic = new Subject()
            {
                Title = "Nhập môn lập trình",
                Credit = 3,
                PricePerCredit = 720000,
                Description = "Hướng dẫn căn bản về môn lập trình",
                CoverImageUrl = "https://lh3.googleusercontent.com/yXpLtgCu1g1aQ31eyC-FyhbGNMkpzPINrrKE-C3LhGSncGdYyQfaPheo0wt3UOJrTv5FlcwmPS2-zYkfegc6ujAWSv7rW8wBXMGCfvjrmdxI4qG0YS8jkTrkLazCetbi6Q"
            };
            dbContext.Add(databaseManagementSystem);
            dbContext.Add(programingBasic);

            TeacherSubject teacherSubject1 = new TeacherSubject
            {
                Code = "Test-123",
                Teacher = teacher,
                Semester = semester,
                Subject = databaseManagementSystem
            };
            TeacherSubject teacherSubject2 = new TeacherSubject
            {
                Code = "Test-124",
                Teacher = teacher,
                Semester = semester,
                Subject = programingBasic
            };
            StudentClass studentClass = new StudentClass()
            {
                Student = student,
                Subject = teacherSubject1,
                Semester = semester,
                StartAt = DateTime.Today,
                EndAt = DateTime.Today.AddMonths(5)
            };
            dbContext.Add(studentClass);
            dbContext.Add(teacherSubject1);
            dbContext.Add(teacherSubject2);

            SubjectSection section = new SubjectSection
            {
                Title = "Chương 1",
                FromDate = DateTime.Today,
                ToDate = DateTime.Today.AddDays(30),
                Order = 1,
                TeacherSubject = teacherSubject1,
            };
            dbContext.Add(section);
            SubjectSection childSection = new SubjectSection
            {
                Title = "Buổi 1",
                FromDate = DateTime.Today,
                ToDate = DateTime.Today.AddDays(5),
                Order = 1,
                Root = section,
                TeacherSubject = teacherSubject1
            };
            SubjectSection childSection2 = new SubjectSection
            {
                Title = "Buổi 2",
                FromDate = DateTime.Today.AddDays(5),
                ToDate = DateTime.Today.AddDays(10),
                Order = 2,
                Root = section,
                TeacherSubject = teacherSubject1
            };
            section.Children.Add(childSection);
            Exam exam = new Exam
            {
                Title = "Test exam",
                Description = "Test exam"
            };
            dbContext.Add(exam);
            MultichoiceQuestion question = new MultichoiceQuestion
            {
                Title = "Chọn đáp án đúng",
                Content = "Con chó trong tiếng Anh là gì",
                Answers = new List<Answer>()
                {
                    new BasicAnswer
                    {
                        Content = "Dog",
                        IsCorrectAnswer = true
                    },
                    new BasicAnswer
                    {
                        Content = "Cat",
                        IsCorrectAnswer = false
                    },
                    new BasicAnswer
                    {
                        Content = "Duck",
                        IsCorrectAnswer = false
                    }
                }
            };
            MultichoiceQuestion question2 = new MultichoiceQuestion
            {
                Title = "Chọn đáp án đúng",
                Content = "Con vịt trong tiếng Anh là gì",
                Answers = new List<Answer>()
                {
                    new BasicAnswer
                    {
                        Content = "Dog",
                        IsCorrectAnswer = false
                    },
                    new BasicAnswer
                    {
                        Content = "Cat",
                        IsCorrectAnswer = false
                    },
                    new BasicAnswer
                    {
                        Content = "Duck",
                        IsCorrectAnswer = true
                    }
                }
            };
            MultichoiceQuestion question3 = new MultichoiceQuestion
            {
                Title = "Chọn đáp án đúng",
                Content = "Con mèo trong tiếng Anh là gì",
                Answers = new List<Answer>()
                {
                    new BasicAnswer
                    {
                        Content = "Dog",
                        IsCorrectAnswer = false
                    },
                    new BasicAnswer
                    {
                        Content = "Cat",
                        IsCorrectAnswer = true
                    },
                    new BasicAnswer
                    {
                        Content = "Duck",
                        IsCorrectAnswer = false
                    }
                }
            };
            dbContext.Add(question);
            dbContext.Add(question2);
            dbContext.Add(question3);
            QuestionAllocation questionAllocation = new QuestionAllocation
            {
                Question = question,
                Exam = exam
            };
            QuestionAllocation questionAllocation2 = new QuestionAllocation
            {
                Question = question2,
                Exam = exam
            };
            QuestionAllocation questionAllocation3 = new QuestionAllocation
            {
                Question = question3,
                Exam = exam
            };
            exam.Questions.Add(questionAllocation);
            exam.Questions.Add(questionAllocation2);
            exam.Questions.Add(questionAllocation3);

            ExamScript examScript = new ExamScript
            {
                OpenAt = DateTime.Today,
                DueTo = DateTime.Today.AddDays(10),
                Exam = exam,
                Order = 3,
            };
            AssignmentScript assignment = new AssignmentScript
            {
                Title = "Nộp bài tập",
                Description = "BÀi tập test",
                Detail = "Làm theo file hướng dẫn",
                OpenAt = DateTime.Now.AddDays(2),
                DueTo = DateTime.Now.AddDays(4),
                Order = 4,
            };
            ContextScript contextScript = new ContextScript
            {
                Heading = "What is Lorem Ipsum?",
                Body = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                Footer = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                Order = 2
            };
            DocumentScript documentScript = new DocumentScript
            {
                DocumentTitle = "Tài liệu 1",
                FileType = "pdf",
                DocumentUrl = "http://www.africau.edu/images/default/sample.pdf",
                Order = 1
            };
            childSection.Scripts.Add(documentScript);
            childSection.Scripts.Add(contextScript);
            childSection.Scripts.Add(examScript);
            childSection.Scripts.Add(assignment);
            section.Children.Add(childSection2);


            AssignmentScript assignment2 = new AssignmentScript
            {
                Title = "Nộp bài tập",
                Description = "BÀi tập test",
                Detail = "Làm theo file hướng dẫn",
                OpenAt = DateTime.Now.AddDays(2),
                DueTo = DateTime.Now.AddDays(4),
                Order = 1,
            };
            childSection2.Scripts.Add(assignment2);

            SubjectSection section1 = new SubjectSection
            {
                Title = "Chương 2",
                FromDate = DateTime.Today.AddDays(30),
                ToDate = DateTime.Today.AddDays(60),
                Order = 2,
                TeacherSubject = teacherSubject1,
            };
            dbContext.Add(section1);
            SubjectSection section2 = new SubjectSection
            {
                Title = "Chương 3",
                FromDate = DateTime.Today.AddDays(60),
                ToDate = DateTime.Today.AddDays(90),
                Order = 3,
                TeacherSubject = teacherSubject1,
            };
            dbContext.Add(section2);

            SubjectSchedule schedule1 = new SubjectSchedule
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(90),
                Subject = teacherSubject1

            };
            SubjectSchedule schedule2 = new SubjectSchedule
            {
                StartTime = DateTime.Now.AddMinutes(45),
                EndTime = DateTime.Now.AddMinutes(135),
                Subject = teacherSubject2
            };
            teacherSubject1.Schedules.Add(schedule1);
            teacherSubject2.Schedules.Add(schedule2);


            dbContext.SaveChanges();
        }
    }
}
