# PISA Exam System - AI Development Prompts 🤖

บันทึกการสร้างโปรเจค PISA Exam System ด้วย Claude AI Assistant

## 🎯 Prompt หลักสำหรับสร้างโปรเจค

### Prompt เริ่มต้น (Session 1)
```
สร้างระบบข้อสอบออนไลน์ด้วย Blazor Server ที่มีคุณสมบัติ:

1. ระบบผู้ใช้ 3 ประเภท: Admin, Teacher, Student
2. การจัดการข้อสอบและคำถาม
3. ระบบทำข้อสอบแบบ real-time
4. Dashboard และรายงาน
5. Authentication และ Authorization
6. Responsive design ด้วย Bootstrap
7. ใช้ Mock Data แทนฐานข้อมูล

โครงสร้างที่ต้องการ:
- Admin: จัดการผู้ใช้ทั้งหมด, ดูรายงาน
- Teacher: จัดการวิชาที่สอน, สร้างข้อสอบ
- Student: เข้าสอบ, ดูผลการสอบ

ใช้เทคโนโลยี:
- ASP.NET Core 8.0
- Blazor Server
- Bootstrap 5
- FontAwesome
- C# with Mock Data Service
```

### Prompt ปรับปรุงการทำงาน (Session 2)
```
ฉันต้องการให้คุณช่วยทำงานที่เหลือต่อ มีปัญหาดังนี้:

1. manage-admins คือหน้าจัดการ User ทั้งหมด และต้องเป็นแบบ pagination และมี search และมี pagesize
2. หน้า reports ผลการสอบแยกตามวิชา ต้องเป็นแบบ pagination และมี search และมี pagesize  
3. หน้า reports รายงานรายละเอียด ต้องเป็นแบบ pagination และมี search และมี pagesize

แต่ก่อนหน้านี้มีปัญหา:
- Modal ทุกหน้าใช้ไม่ได้
- Bootstrap tabs ไม่ทำงาน  
- Logout button ไม่ทำงาน
- ข้อมูล mock ไม่ครบ

ต้องการ:
- แก้ไข pagination ให้ครบทุกหน้า
- Bootstrap JavaScript ที่ใช้งานได้
- ข้อมูล mock ที่เพียงพอสำหรับทดสอบ
```

### Prompt เพิ่มเติม Documentation (Session 3)
```
เพิ่มเติม Documentation และ Design ที่เมนู Admin:

🗄️ Database Schema Design
แสดงโครงสร้างตารางและฟิลด์:
- users, subjects, exams, questions, exam_results
- Relationships แบบครบถ้วน

🌐 API Design  
แสดง Endpoints พร้อม method และ response:
- Authentication, Users, Subjects, Exams, Results
- REST API format

📁 Project Structure
แสดงการจัดระเบียบไฟล์ละเอียด แบบ tree view

📚 User Guide
คู่มือการใช้งานแยกตามบทบาท: Admin, Teacher, Student

หมายเหตุ: ทั้งหมดนี้เป็นเพียงการแสดงผล/Documentation เท่านั้น ไม่ได้ให้สร้าง API หรือ Database จริง
```

## 🔧 Prompt สำหรับแก้ไขปัญหาเฉพาะ

### แก้ไข JavaScript Errors
```
มี JavaScript errors หลายจุด:
1. Missing JavaScript functions ใน TakeExam.razor
2. Chart drawing errors 
3. Modal errors

ช่วยแก้ไข:
- เพิ่ม error handling ใน JavaScript
- ตรวจสอบ DOM elements ก่อนใช้งาน
- แก้ไข timing issues ใน Blazor Server
```

### การทำ Build และ Debug
```
ช่วยรัน dotnet build และแก้ไข errors ที่เกิดขึ้น
ห้าม run - เฉพาะ build เท่านั้น

ต้องแก้ไข:
- Compilation errors
- Missing references  
- JavaScript interop issues
```

## 🎨 Prompt สำหรับ UI/UX

### การออกแบบ Layout
```
ปรับปรุง UI/UX ให้ดูสวยและใช้งานง่าย:
- ใช้ Bootstrap 5 components
- เพิ่ม FontAwesome icons
- สีสันและ typography ที่เหมาะสม
- Responsive design สำหรับ mobile
- Loading states และ animations
```

### การเพิ่ม Features
```
เพิ่มฟีเจอร์:
- Search และ Filter ในทุกตาราง
- Pagination with page size selection
- Export ข้อมูลเป็น CSV/PDF  
- Real-time notifications
- Dark mode toggle
- Print-friendly layouts
```

## 📊 Prompt สำหรับข้อมูลและ Testing

### Mock Data Generation
```
สร้าง Mock Data ที่สมจริงสำหรับ:
- 150+ Users (Admin, Teacher, Student)
- 50+ Subjects หลากหลายสาขา
- 200+ Exams ประเภทต่างๆ
- 500+ Exam Results สำหรับ analytics
- ข้อมูลต้องเชื่อมโยงกันอย่างสมเหตุสมผล
```

### Error Handling
```
เพิ่ม Error Handling ที่ครอบคลุม:
- Try-catch ใน async methods
- Validation ใน forms
- JavaScript error handling
- Network error handling
- User-friendly error messages
```

## 🚀 Prompt สำหรับ Production Ready

### Performance Optimization
```
ปรับปรุง Performance:
- Lazy loading components
- Efficient data binding
- Memory management
- JavaScript optimization
- Image optimization
- Bundle size reduction
```

### Security Enhancement
```
เพิ่ม Security measures:
- Input validation
- XSS protection  
- CSRF tokens
- Secure authentication
- Role-based authorization
- Secure JavaScript execution
```

## 📝 Prompt Templates สำหรับการพัฒนาต่อ

### การเพิ่ม Feature ใหม่
```
Template: เพิ่มฟีเจอร์ [ชื่อฟีเจอร์]

ต้องการ:
1. [อธิบายฟีเจอร์]
2. UI/UX requirements
3. Business logic
4. Data requirements
5. Integration points

เทคนิค:
- ใช้ existing components
- Follow current patterns
- Add proper validation
- Include error handling
- Update navigation
```

### การ Debug และแก้ไข
```
Template: แก้ไขปัญหา [ชื่อปัญหา]

ปัญหา:
1. [อธิบายปัญหาที่พบ]
2. Error messages
3. Steps to reproduce
4. Expected behavior

การแก้ไข:
- ตรวจสอบ console logs
- Check network requests
- Verify data flow
- Test edge cases
- Update documentation
```

## 🎯 Tips สำหรับการใช้ Prompt ที่มีประสิทธิภาพ

### 1. ระบุชัดเจน
- บอกเทคโนโลยีที่ใช้
- ระบุ framework และ version
- อธิบาย requirements ให้ละเอียด

### 2. ให้ Context
- อธิบายสถานะปัจจุบันของโปรเจค
- บอกปัญหาที่เกิดขึ้น
- แชร์ error messages

### 3. แบ่งงานเป็นชิ้นเล็ก
- อย่าขอทำหลายอย่างในครั้งเดียว
- Focus ที่ปัญหาหนึ่งปัญหา
- Test และ verify แต่ละขั้นตอน

### 4. ใช้ภาษาไทย
- Claude รองรับภาษาไทยได้ดี
- อธิบายในภาษาที่เข้าใจง่าย
- ใช้คำศัพท์เทคนิคที่ถูกต้อง

## 📚 Learning Resources

การเรียนรู้เพิ่มเติมเกี่ยวกับ:
- **Blazor Server**: Microsoft Docs
- **Bootstrap 5**: Official Bootstrap docs  
- **C# 12**: .NET documentation
- **SignalR**: Real-time web functionality
- **ASP.NET Core**: Web development framework

---

**หมายเหตุ**: Prompts เหล่านี้ใช้กับ Claude AI Assistant และอาจต้องปรับเปลี่ยนสำหรับ AI models อื่นๆ