# Inheritance — Uy vazifasi (sodda yechim)

## Ishga tushirish

```bash
cd InheritanceHomework
dotnet run
```

## Kutilgan natija

```
=== 1. Person va Student ===
Salom, men Ali.
C#

=== 2. Employee, Developer, Designer ===
Malika, IT
C#
Jasur, Design
Figma

=== 3. Device va Phone ===
Pixel
Pixel

=== 4. Notification ===
Email xabar: ali@example.com
Email objectini SMS ga aylantirib bo'lmadi (null)
SMS raqami: +998901234567

=== 5. OnlineCourse ===
Kurs nomi: C#
Platforma: Online
Base class: Course
```

## Qisqacha tushuntirish

| Mavzu | Ma'nosi |
|---|---|
| `class B : A` | B classi A dan meros oladi |
| `: base(name)` | Qiymatni base class constructoriga uzatadi |
| `private` | Faqat o'sha class ichida ko'rinadi |
| `protected` | O'sha class va undan meros olganlar ichida ko'rinadi |
| `public` | Hamma joydan ko'rinadi |
| `x is Email e` | Tekshiradi va mos bo'lsa `e` o'zgaruvchisini beradi |
| `x as Sms` | Aylantiradi, mos bo'lmasa `null` qaytaradi — shuning uchun `null` ni tekshirish kerak |
| `sealed` | Bu classdan meros olib bo'lmaydi |
| is-a / has-a | `OnlineCourse` **bu** `Course` (meros); `OnlineCourse` **ichida** `LearningPlatform` **bor** (property) |

## Kompilyatsiya xatolarini sinash

`Program.cs` ichida `// XATO` deb yozilgan qatorlar bor. Ularni **bittadan**
izohdan chiqaring → xatoni ko'ring → yana izohga qaytaring:

1. `phone._model` — private
2. `phone.Model` — protected
3. `Phone` ichida `_model` — private, derived classga ko'rinmaydi
4. `class MyPlatform : LearningPlatform` — sealed classdan meros yo'q
5. `class InvalidDerived : BaseOne, BaseTwo` — C# da faqat bitta base class
