// ======================================================
//  UY VAZIFASI — INHERITANCE (soddalashtirilgan yechim)
//  Avval top-level kod, keyin pastda classlar.
// ======================================================


// ---------- 1-MASHQ: Person va Student ----------
Console.WriteLine("=== 1. Person va Student ===");

Student student = new Student("Ali", "C#");
student.Introduce();              // Salom, men Ali.
Console.WriteLine(student.Course); // C#


// ---------- 2-MASHQ: Employee, Developer, Designer ----------
Console.WriteLine("\n=== 2. Employee, Developer, Designer ===");

Developer developer = new Developer("Malika", "IT", "C#");
developer.ShowInfo();                            // Malika, IT
Console.WriteLine(developer.ProgrammingLanguage); // C#

Designer designer = new Designer("Jasur", "Design", "Figma");
designer.ShowInfo();                   // Jasur, Design
Console.WriteLine(designer.DesignTool); // Figma


// ---------- 3-MASHQ: Device va Phone ----------
Console.WriteLine("\n=== 3. Device va Phone ===");

Phone phone = new Phone("Pixel");
phone.ShowModel();      // Pixel  (base classdan meros olingan public method)
phone.ShowPhoneModel(); // Pixel  (Phone ichida protected Model ishlatildi)

// Quyidagilarni BITTADAN izohdan chiqarib ko'ring — kompilyatsiya xatosi chiqadi.
// Keyin yana izohga qaytaring.
// Console.WriteLine(phone._model); // XATO: _model private
// Console.WriteLine(phone.Model);  // XATO: Model protected


// ---------- 4-MASHQ: Notification ----------
Console.WriteLine("\n=== 4. Notification ===");

Notification emailMessage = new EmailNotification("Xush kelibsiz", "ali@example.com");
Notification smsMessage = new SmsNotification("Tasdiqlash kodi", "+998901234567");

// a) is pattern: email xabarmi?
if (emailMessage is EmailNotification email)
{
    Console.WriteLine("Email xabar: " + email.EmailAddress); // ali@example.com
}

// b) Email objectini SMS ga aylantirib ko'ramiz -> null bo'ladi
SmsNotification? wrongSms = emailMessage as SmsNotification;
if (wrongSms == null)
{
    Console.WriteLine("Email objectini SMS ga aylantirib bo'lmadi (null)");
}
else
{
    Console.WriteLine(wrongSms.PhoneNumber);
}

// c) SMS objectini SMS ga aylantiramiz -> muvaffaqiyatli
SmsNotification? sms = smsMessage as SmsNotification;
if (sms != null)
{
    Console.WriteLine("SMS raqami: " + sms.PhoneNumber); // +998901234567
}


// ---------- 5-MASHQ: OnlineCourse ----------
Console.WriteLine("\n=== 5. OnlineCourse ===");

LearningPlatform platform = new LearningPlatform("Online");
OnlineCourse onlineCourse = new OnlineCourse("C#", platform);

Console.WriteLine("Kurs nomi: " + onlineCourse.Name);               // C#
Console.WriteLine("Platforma: " + onlineCourse.Platform.Name);      // Online
Console.WriteLine("Base class: " + typeof(OnlineCourse).BaseType!.Name); // Course



// ======================================================
//                      CLASSLAR
// ======================================================

// ----- 1-mashq -----
class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public void Introduce()
    {
        Console.WriteLine($"Salom, men {Name}.");
    }
}

class Student : Person
{
    public string Course { get; set; }

    // name -> base classga uzatiladi
    public Student(string name, string course) : base(name)
    {
        Course = course;
    }
}


// ----- 2-mashq -----
class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }

    public Employee(string name, string department)
    {
        Name = name;
        Department = department;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name}, {Department}");
    }
}

class Developer : Employee
{
    public string ProgrammingLanguage { get; set; }

    public Developer(string name, string department, string programmingLanguage)
        : base(name, department)
    {
        ProgrammingLanguage = programmingLanguage;
    }
}

// Designer ham Employee dan meros oladi (Developer dan EMAS)
class Designer : Employee
{
    public string DesignTool { get; set; }

    public Designer(string name, string department, string designTool)
        : base(name, department)
    {
        DesignTool = designTool;
    }
}


// ----- 3-mashq -----
class Device
{
    private string _model; // faqat Device ichida ko'rinadi

    protected string Model // Device va undan meros olganlar ichida ko'rinadi
    {
        get { return _model; }
    }

    public Device(string model)
    {
        _model = model;
    }

    public void ShowModel() // hamma joydan chaqirsa bo'ladi
    {
        Console.WriteLine(_model);
    }
}

class Phone : Device
{
    public Phone(string model) : base(model)
    {
    }

    public void ShowPhoneModel()
    {
        Console.WriteLine(Model); // protected -> ishlaydi

        // Console.WriteLine(_model); // XATO: private field derived classga ko'rinmaydi
    }
}


// ----- 4-mashq -----
class Notification
{
    public string Title { get; set; }

    public Notification(string title)
    {
        Title = title;
    }
}

class EmailNotification : Notification
{
    public string EmailAddress { get; set; }

    public EmailNotification(string title, string emailAddress) : base(title)
    {
        EmailAddress = emailAddress;
    }
}

class SmsNotification : Notification
{
    public string PhoneNumber { get; set; }

    public SmsNotification(string title, string phoneNumber) : base(title)
    {
        PhoneNumber = phoneNumber;
    }
}


// ----- 5-mashq -----
class Course
{
    public string Name { get; set; }

    public Course(string name)
    {
        Name = name;
    }
}

sealed class LearningPlatform // sealed -> undan meros olib bo'lmaydi
{
    public string Name { get; set; }

    public LearningPlatform(string name)
    {
        Name = name;
    }
}

// is-a: OnlineCourse — bu Course
// has-a: OnlineCourse ichida LearningPlatform bor
class OnlineCourse : Course
{
    public LearningPlatform Platform { get; set; }

    public OnlineCourse(string name, LearningPlatform platform) : base(name)
    {
        Platform = platform;
    }
}


// ---------- SINOV UCHUN (izohdan chiqarib ko'ring, keyin qaytaring) ----------

// sealed classdan meros olish -> XATO
// class MyPlatform : LearningPlatform
// {
//     public MyPlatform() : base("Test") { }
// }

// Ikki classdan meros olish -> XATO (C# da faqat bitta base class bo'ladi)
// class BaseOne { }
// class BaseTwo { }
// class InvalidDerived : BaseOne, BaseTwo { }
