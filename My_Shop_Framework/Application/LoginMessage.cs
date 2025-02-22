using System.Collections.Generic;

namespace My_Shop_Framework.Application
{
    public static class LoginMessage
    {
        private static readonly Dictionary<string, Dictionary<string, string>> Messages = new()
        {
            {
                "InvalidToken", new Dictionary<string, string>
                {
                    { "fa-ir", "توکن نامعتبر است" },
                    { "en-us", "Invalid verification code" },
                    { "ru_ru", "Недействительный токен" },
                    { "ar", "رمز غير صالح" }
                }
            },
            {
                "UserNotFound", new Dictionary<string, string>
                {
                    { "fa-ir", "کاربر پیدا نشد" },
                    { "en-us", "User not found" },
                    { "ru_ru", "Пользователь не найден" },
                    { "ar", "لم يتم العثور على المستخدم" }
                }
            },
            {
                "SessionExpired", new Dictionary<string, string>
                {
                    { "fa-ir", "سشن منقضی شد. لطفا دوباره امتحان کنید" },
                    { "en-us", "Session expired. Please try again" },
                    { "ru_ru", "Сессия истекла. Попробуйте еще раз." },
                    { "ar", "انتهت الجلسة. يرجى المحاولة مرة أخرى" }
                }
            },
            {
                "LoginUser", new Dictionary<string, string>
                {
                    { "fa-ir", "ورود کاربر" },
                    { "en-us", "Login User" },
                    { "ru_ru", "Логин пользователя" },
                    { "ar", "تسجيل دخول المستخدم" }
                }
            },
            {
                "LoginFailed", new Dictionary<string, string>
                {
                    { "fa-ir", "ورود ناموفق" },
                    { "en-us", "Login failed" },
                    { "ru_ru", "Ошибка входа" },
                    { "ar", "فشل تسجيل الدخول" }
                }
            },
            {
                "PhoneNotRegistered", new Dictionary<string, string>
                {
                    { "fa-ir", "شماره تلفن ثبت یا تایید نشده است" },
                    { "en-us", "Phone number is not registered or confirmed" },
                    { "ru_ru", "Номер телефона не зарегистрирован или не подтвержден" },
                    { "ar", "رقم الهاتف غير مسجل أو مؤكد" }
                }
            },
            {
                "EmailEmpty", new Dictionary<string, string>
                {
                    { "fa-ir", "شماره تلفن ثبت یا تایید نشده است" },
                    { "en-us", "Email cannot be empty" },
                    { "ru_ru", "Электронная почта не может быть пустой" },
                    { "ar", "لا يمكن أن يكون البريد الإلكتروني فارغًا" }
                }
            },
            {
                "EmailFormat", new Dictionary<string, string>
                {
                    { "fa-ir", "فرمت ایمیل معتبر نیست" },
                    { "en-us", "The email format is not valid" },
                    { "ru_ru", "Недопустимый формат электронной почты." },
                    { "ar", "صيغة البريد الإلكتروني غير صالحة" }
                }
            },
            {
                "UserNotFound", new Dictionary<string, string>
                {
                    { "fa-ir", "کاربری با اطلاعات زیز یافت نشد" },
                    { "en-us", "User not found" },
                    { "ru_ru", "Пользователь не найден" },
                    { "ar", "لم يتم العثور على المستخدم" }
                }
            },
            {
                "UpdatingEmail", new Dictionary<string, string>
                {
                    { "fa-ir", "خطایی در به‌روزرسانی ایمیل رخ داد" },
                    { "en-us", "There was an error updating email" },
                    { "ru_ru", "Произошла ошибка при обновлении электронной почты" },
                    { "ar", "حدث خطأ أثناء تحديث البريد الإلكتروني" }
                }
            },
            {
                "SendEmail", new Dictionary<string, string>
                {
                    { "fa-ir", "خطایی در ارسال ایمیل رخ داد" },
                    { "en-us", "There was an error sending the email" },
                    { "ru_ru", "Произошла ошибка при отправке письма" },
                    { "ar", "حدث خطأ أثناء إرسال البريد الإلكتروني" }
                }
            },
            {
                "SendSuccess", new Dictionary<string, string>
                {
                    { "fa-ir", "ایمیل با موفقیت ذخیره شد" },
                    { "en-us", "Email saved successfully." },
                    { "ru_ru", "Электронная почта успешно сохранена." },
                    { "ar", "تم حفظ البريد الإلكتروني بنجاح." }
                }
            },
            {
                "SaveEmail", new Dictionary<string, string>
                {
                    { "fa-ir", "خطایی در ذخیره‌سازی ایمیل رخ داد" },
                    { "en-us", "An error occurred while storing the email" },
                    { "ru_ru", "Произошла ошибка при сохранении письма." },
                    { "ar", "حدث خطأ أثناء تخزين البريد الإلكتروني" }
                }
            },
            {
                "EmailVerification", new Dictionary<string, string>
                {
                    { "fa-ir", "تأیید ایمیل" },
                    { "en-us", "Email verification" },
                    { "ru_ru", "Подтверждение по электронной почте" },
                    { "ar", "التحقق من البريد الإلكتروني" }
                }
            }
        };

        public static string GetMessage(string messageCode, string languageCode)
        {
            if (Messages.ContainsKey(messageCode))
            {
                if (Messages[messageCode].ContainsKey(languageCode.ToLower()))
                {
                    return Messages[messageCode][languageCode.ToLower()];
                }
            }

            return Messages[messageCode]["en"];
        }
    }
}