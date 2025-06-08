using PISA_APP.Models;

namespace PISA_APP.Services
{
    public class MockDataService
    {
        private List<User> _users;
        private List<Subject> _subjects;
        private List<Exam> _exams;
        private List<ExamResult> _examResults;

        public MockDataService()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Initialize Users - Extended Mock Data (150+ users)
            _users = new List<User>();
            
            // Add 5 Admins
            for (int i = 1; i <= 5; i++)
            {
                _users.Add(new Admin
                {
                    Id = i,
                    Username = $"admin{i:D2}",
                    Password = "admin123",
                    FullName = $"ผู้ดูแลระบบ {i}",
                    Email = $"admin{i}@pisa.edu",
                    PhoneNumber = $"02-123-{4567 + i:D4}",
                    IsActive = true
                });
            }

            // Add 25 Teachers
            string[] teacherSubjects = { "คณิตศาสตร์", "ฟิสิกส์", "เคมี", "ชีววิทยา", "ภาษาไทย", "ภาษาอังกฤษ", "สังคมศึกษา", "ประวัติศาสตร์", "ภูมิศาสตร์", "ศิลปศึกษา", "พลศึกษา", "คอมพิวเตอร์", "วิทยาศาสตร์ทั่วไป", "การงานอาชีพ", "สุขศึกษา" };
            string[] teacherFirstNames = { "สมชาย", "สมหญิง", "วิชัย", "สุมาลี", "ประภาส", "กนกวรรณ", "อนุชา", "พิมพ์ใจ", "รัตนา", "ชาญชัย", "อรุณี", "บุญญฤทธิ์", "มณีรัตน์", "สุรชัย", "วิมลรัตน์", "ธีรพงษ์", "นิภา", "กิตติ", "สุวิมล", "ประวิทย์", "มยุรี", "สำราญ", "พรรณี", "วิรัช", "สุนิสา" };
            
            for (int i = 1; i <= 25; i++)
            {
                var subjectName = teacherSubjects[(i - 1) % teacherSubjects.Length];
                var firstName = teacherFirstNames[(i - 1) % teacherFirstNames.Length];
                _users.Add(new Teacher
                {
                    Id = 5 + i,
                    Username = $"teacher{i:D3}",
                    Password = "teacher123",
                    FullName = $"อาจารย์{firstName} {subjectName}",
                    Email = $"teacher{i}@pisa.edu",
                    PhoneNumber = $"08-{100 + i:D3}-{1000 + i:D4}",
                    AssignedSubjectIds = new List<int> { i, i + 25 },
                    IsActive = true
                });
            }

            // Add 120 Students
            string[] studentFirstNames = { "สมศักดิ์", "สุดา", "อนุชา", "มนัสวี", "ธนกร", "นิติกร", "ปริญญา", "วรรณา", "ศิริ", "กมล", "วิชัย", "สุพิชญา", "รัชนี", "ประวิท", "นันทนา", "อดิศักดิ์", "พิมพ์ใจ", "ชนิดา", "สุรศักดิ์", "กิตติยา" };
            string[] studentLastNames = { "ใจดี", "ขยัน", "เรียนดี", "มานะ", "รักเรียน", "ตั้งใจ", "พยายาม", "สุภาพ", "เก่ง", "เฉลียว", "ซื่อสัตย์", "ขมิน", "ฟ้า", "ขาว", "แดง", "เขียว", "เหลือง", "น้ำเงิน", "ม่วง", "ส้ม" };
            
            for (int i = 1; i <= 120; i++)
            {
                var firstName = studentFirstNames[(i - 1) % studentFirstNames.Length];
                var lastName = studentLastNames[(i - 1) % studentLastNames.Length];
                var prefix = i % 2 == 0 ? "นางสาว" : "นาย";
                _users.Add(new Student
                {
                    Id = 30 + i,
                    Username = $"student{i:D3}",
                    Password = "student123",
                    FullName = $"{prefix}{firstName} {lastName}",
                    Email = $"student{i}@student.pisa.edu",
                    PhoneNumber = $"09-{200 + i % 100:D2}-{3000 + i:D4}",
                    StudentId = $"{64 + (i - 1) / 100:D2}0{10000 + i:D5}".Substring(0, 8),
                    EnrolledSubjectIds = GenerateRandomSubjectIds(i),
                    IsActive = i % 10 != 0 // 90% active students
                });
            };

            // Initialize Subjects - 50+ subjects
            _subjects = new List<Subject>();
            string[] subjectNames = { 
                "คณิตศาสตร์พื้นฐาน", "คณิตศาสตร์ขั้นสูง", "พีชคณิต", "เรขาคณิต", "ตรีโกณมิติ",
                "ฟิสิกส์ทั่วไป", "ฟิสิกส์คลื่น", "กลศาสตร์", "อุณหพลศาสตร์", "แสงและเสียง",
                "เคมีทั่วไป", "เคมีอนินทรีย์", "เคมีอินทรีย์", "เคมีวิเคราะห์", "เคมีฟิสิกส์",
                "ชีววิทยาทั่วไป", "พฤกษศาสตร์", "สัตววิทยา", "พันธุศาสตร์", "นิเวศวิทยา",
                "ภาษาไทย", "วรรณคดี", "ภาษาศาสตร์", "การเขียน", "การอ่าน",
                "ภาษาอังกฤษ", "ไวยากรณ์", "การฟัง-พูด", "การอ่าน-เขียน", "วรรณกรรม",
                "ประวัติศาสตร์", "ประวัติศาสตร์ไทย", "ประวัติศาสตร์โลก", "โบราณคดี", "มานุษยวิทยา",
                "ภูมิศาสตร์", "ภูมิศาสตร์กายภาพ", "ภูมิศาสตร์มนุษย์", "แผนที่", "ธรณีวิทยา",
                "คอมพิวเตอร์", "การเขียนโปรแกรม", "ฐานข้อมูล", "เครือข่าย", "ปัญญาประดิษฐ์",
                "ศิลปศึกษา", "ดนตรี", "นาฏศิลป์", "ทัศนศิลป์", "วรรณศิลป์",
                "พลศึกษา", "กีฬา", "สุขภาพ", "โภชนาการ", "การออกกำลังกาย"
            };
            string[] subjectCodes = {
                "MATH", "PHYS", "CHEM", "BIOL", "THAI", "ENG", "HIST", "GEOG", "COMP", "ART", "PE"
            };

            for (int i = 1; i <= 50; i++)
            {
                var subjectName = subjectNames[(i - 1) % subjectNames.Length];
                var codePrefix = subjectCodes[(i - 1) % subjectCodes.Length];
                var teacherId = 6 + (i - 1) % 25; // Assign to teachers (IDs 6-30)
                
                _subjects.Add(new Subject
                {
                    Id = i,
                    Name = subjectName,
                    Code = $"{codePrefix}{100 + i}",
                    Description = $"รายวิชา{subjectName} สำหรับนักศึกษา",
                    TeacherId = teacherId,
                    ExamIds = new List<int>(),
                    IsActive = i % 8 != 0 // 87.5% active subjects
                });
            }

            // Initialize Exams - 200+ exams
            _exams = new List<Exam>();
            string[] examTypes = { "สอบกลางภาค", "สอบปลายภาค", "สอบย่อย", "แบบทดสอบ", "ควิซ" };
            var random = new Random(42); // Fixed seed for consistent data
            
            for (int i = 1; i <= 200; i++)
            {
                var subjectId = ((i - 1) % 50) + 1;
                var examType = examTypes[(i - 1) % examTypes.Length];
                var subject = _subjects.Find(s => s.Id == subjectId);
                
                var exam = new Exam
                {
                    Id = i,
                    Title = $"{examType} {subject?.Name ?? "วิชาทั่วไป"} ครั้งที่ {((i - 1) / 50) + 1}",
                    Description = $"การ{examType} วิชา {subject?.Name ?? "วิชาทั่วไป"}",
                    SubjectId = subjectId,
                    StartDate = DateTime.Now.AddDays(random.Next(-60, 30)),
                    EndDate = DateTime.Now.AddDays(random.Next(31, 90)),
                    Duration = examType == "ควิซ" ? 30 : examType == "สอบย่อย" ? 60 : 120,
                    TotalPoints = examType == "ควิซ" ? 50 : 100,
                    IsActive = i % 15 != 0, // 93% active exams
                    Questions = GenerateQuestionsForExam(i, examType),
                    CreatedDate = DateTime.Now.AddDays(random.Next(-90, -10))
                };
                
                _exams.Add(exam);
                
                // Update subject's exam list
                if (subject != null)
                {
                    subject.ExamIds.Add(i);
                }
            }

            // Initialize Exam Results - 500+ results
            _examResults = new List<ExamResult>();
            int resultId = 1;
            
            // Generate exam results for students
            for (int studentId = 31; studentId <= 150; studentId++) // 120 students
            {
                var student = _users.Find(u => u.Id == studentId) as Student;
                if (student?.EnrolledSubjectIds != null)
                {
                    // Each student takes 3-8 exams randomly
                    var examCount = random.Next(3, 9);
                    var availableExams = _exams.Where(e => student.EnrolledSubjectIds.Contains(e.SubjectId) && e.IsActive).ToList();
                    
                    for (int i = 0; i < Math.Min(examCount, availableExams.Count); i++)
                    {
                        var exam = availableExams[random.Next(availableExams.Count)];
                        availableExams.Remove(exam); // Don't take same exam twice
                        
                        var startTime = exam.StartDate.AddDays(random.Next(0, (exam.EndDate - exam.StartDate).Days));
                        var endTime = startTime.AddMinutes(random.Next(exam.Duration / 2, exam.Duration + 10));
                        var score = random.Next(30, exam.TotalPoints + 1);
                        
                        _examResults.Add(new ExamResult
                        {
                            Id = resultId++,
                            StudentId = studentId,
                            ExamId = exam.Id,
                            StartTime = startTime,
                            EndTime = endTime,
                            Score = score,
                            TotalPoints = exam.TotalPoints,
                            IsCompleted = random.Next(100) < 95, // 95% completion rate
                            Answers = GenerateRandomAnswers(exam, score)
                        });
                    }
                }
            }
        }

        private List<int> GenerateRandomSubjectIds(int studentIndex)
        {
            var random = new Random(studentIndex);
            var subjectCount = random.Next(3, 8); // Each student enrolls in 3-7 subjects
            var subjectIds = new List<int>();
            
            while (subjectIds.Count < subjectCount)
            {
                var subjectId = random.Next(1, 51); // 50 subjects available
                if (!subjectIds.Contains(subjectId))
                {
                    subjectIds.Add(subjectId);
                }
            }
            
            return subjectIds;
        }

        private List<Question> GenerateQuestionsForExam(int examId, string examType)
        {
            var questions = new List<Question>();
            var random = new Random(examId);
            var questionCount = examType == "ควิซ" ? random.Next(5, 11) : random.Next(10, 26);
            
            string[] questionTemplates = {
                "คำถามที่ {0} ของข้อสอบ {1}",
                "ข้อ {0}: หาคำตอบที่ถูกต้อง",
                "คำถาม {0} เกี่ยวกับเนื้อหาสำคัญ",
                "ข้อที่ {0} ทดสอบความเข้าใจ"
            };
            
            for (int i = 1; i <= questionCount; i++)
            {
                var isMultipleChoice = random.Next(100) < 70; // 70% multiple choice
                var points = examType == "ควิซ" ? random.Next(2, 6) : random.Next(3, 8);
                
                questions.Add(new Question
                {
                    Id = (examId * 1000) + i,
                    Text = string.Format(questionTemplates[random.Next(questionTemplates.Length)], i, examId),
                    Type = isMultipleChoice ? QuestionType.MultipleChoice : QuestionType.ShortAnswer,
                    Options = isMultipleChoice ? new List<string> { "ตัวเลือก A", "ตัวเลือก B", "ตัวเลือก C", "ตัวเลือก D" } : null,
                    CorrectAnswer = isMultipleChoice ? new[] { "ตัวเลือก A", "ตัวเลือก B", "ตัวเลือก C", "ตัวเลือก D" }[random.Next(4)] : "คำตอบที่ถูกต้อง",
                    Points = points
                });
            }
            
            return questions;
        }

        private List<StudentAnswer> GenerateRandomAnswers(Exam exam, int targetScore)
        {
            var answers = new List<StudentAnswer>();
            var random = new Random(exam.Id + targetScore);
            int currentScore = 0;
            
            foreach (var question in exam.Questions)
            {
                var shouldBeCorrect = currentScore < targetScore && random.Next(100) < 75;
                var answer = shouldBeCorrect ? question.CorrectAnswer : "คำตอบผิด";
                var points = shouldBeCorrect ? question.Points : 0;
                
                answers.Add(new StudentAnswer
                {
                    QuestionId = question.Id,
                    Answer = answer,
                    IsCorrect = shouldBeCorrect,
                    Points = points
                });
                
                currentScore += points;
            }
            
            return answers;
        }

        // User methods
        public List<User> GetAllUsers() => _users;
        public User? GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);
        public List<User> GetUsersByRole(UserRole role) => _users.Where(u => u.Role == role).ToList();
        public void AddUser(User user) { user.Id = _users.Max(u => u.Id) + 1; _users.Add(user); }
        public void UpdateUser(User user) { var index = _users.FindIndex(u => u.Id == user.Id); if (index >= 0) _users[index] = user; }
        public void DeleteUser(int id) => _users.RemoveAll(u => u.Id == id);

        // Subject methods
        public List<Subject> GetAllSubjects() => _subjects;
        public Subject? GetSubjectById(int id) => _subjects.FirstOrDefault(s => s.Id == id);
        public List<Subject> GetSubjectsByTeacher(int teacherId) => _subjects.Where(s => s.TeacherId == teacherId).ToList();
        public void AddSubject(Subject subject) { subject.Id = _subjects.Any() ? _subjects.Max(s => s.Id) + 1 : 1; _subjects.Add(subject); }
        public void UpdateSubject(Subject subject) { var index = _subjects.FindIndex(s => s.Id == subject.Id); if (index >= 0) _subjects[index] = subject; }
        public void DeleteSubject(int id) => _subjects.RemoveAll(s => s.Id == id);

        // Exam methods
        public List<Exam> GetAllExams() => _exams;
        public Exam? GetExamById(int id) => _exams.FirstOrDefault(e => e.Id == id);
        public List<Exam> GetExamsBySubject(int subjectId) => _exams.Where(e => e.SubjectId == subjectId).ToList();
        public void AddExam(Exam exam) { exam.Id = _exams.Any() ? _exams.Max(e => e.Id) + 1 : 1; _exams.Add(exam); }
        public void UpdateExam(Exam exam) { var index = _exams.FindIndex(e => e.Id == exam.Id); if (index >= 0) _exams[index] = exam; }
        public void DeleteExam(int id) => _exams.RemoveAll(e => e.Id == id);

        // Exam Result methods
        public List<ExamResult> GetAllExamResults() => _examResults;
        public ExamResult? GetExamResultById(int id) => _examResults.FirstOrDefault(r => r.Id == id);
        public List<ExamResult> GetExamResultsByStudent(int studentId) => _examResults.Where(r => r.StudentId == studentId).ToList();
        public List<ExamResult> GetExamResultsByExam(int examId) => _examResults.Where(r => r.ExamId == examId).ToList();
        public void AddExamResult(ExamResult result) { result.Id = _examResults.Any() ? _examResults.Max(r => r.Id) + 1 : 1; _examResults.Add(result); }
        public void UpdateExamResult(ExamResult result) { var index = _examResults.FindIndex(r => r.Id == result.Id); if (index >= 0) _examResults[index] = result; }
        public void DeleteExamResult(int id) => _examResults.RemoveAll(r => r.Id == id);
    }
}