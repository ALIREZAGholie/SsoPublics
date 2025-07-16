namespace Contracts
{
    public class Constant
    {
        public static class Application
        {
            public static string Name;
        }

        public static class Url
        {
            public static string AdPictureSample = @"../Solution Items/Data/AdPictureSample.json";
            public static string AdSample = @"../Solution Items/Data/AdSample.json";
            public static string AdSpecValue = @"../Solution Items/Data/AdSpecValue.json";
            public static string CategorySample = @"../Solution Items/Data/CategorySample.json";
            public static string InputType = @"../Solution Items/Data/InputType.json";
            public static string Role = @"../Solution Items/Data/Role.json";
            public static string SpecGroupSample = @"../Solution Items/Data/SpecGroupSample.json";
            public static string CategorySpecGroupSample = @"../Solution Items/Data/CategorySpecGroupSample.json";
            public static string SpecGroupSpecSample = @"../Solution Items/Data/SpecGroupSpecSample.json";
            public static string SpecSample = @"../Solution Items/Data/SpecSample.json";
            public static string SpecValueSample = @"../Solution Items/Data/SpecValueSample.json";
            public static string Status = @"../Solution Items/Data/Status.json";
            public static string UserSample = @"../Solution Items/Data/UserSample.json";
        }

        public static class ErrorMessage
        {
            public const string NotFoundMessage = "Could not find";
            public const string AppConfigurationMessage = "AppConfiguration cannot be null";
        }

        public static class SeedingMessage
        {
            public static string SeedDataSuccessMessage = "داده‌ها با موفقیت ذخیره شد";
        }

        public static class ErrorRespondCode
        {
            public const string NotFound = "موردی یافت نشد";
            public const string VersionConflict = "تضاد نسخه";
            public const string ItemAlreadyExists = "آیتم مورد نظر موجود است";
            public const string Conflict = "تضاد";
            public const string BadRequest = "درخواست نادرست";
            public const string Unauthorized = "عدم دسترسی";
            public const string InternalError = "اشکال در روند برنامه";
            public const string GeneralError = "خطای عمومی";
            public const string UnprocessableEntity = "موجودیت غیرقابل پردازش";
        }

        public static class MessageShowType
        {
            public const string None = "none";
            public const string Dialog = "dialog";
            public const string Snack = "snack";
        }

        public static class MessageCodeType
        {
            public const int Success = 1;
            public const int Warning = 2;
            public const int Error = 3;
        }

        public static class CRMActionType
        {
            public const string Lead = "Lead";
            public const string Opportunity = "Opportunity";
        }

        public static class NotifAlarmMessage
        {
            public const string Lead = "سرنخ جدیدی برای شما ایجاد شده است";
            public const string Opportunity = "فرصت جدید برای شما ایجاد شده است";
            public const string Activity = "فعالیت جدیدی برای شما ایجاد شده است";
        }

        public static class ClaimType
        {
            public const string Permission = "Permission";
            public const string Department = "Department";
            public const string ModuleAccess = "ModuleAccess";
            public const string AccessLevel = "AccessLevel";
            public const string Operation = "Operation";
            public const string Scope = "Scope";
            public const string Policy = "Policy";
            public const string Language = "Language";
            public const string Theme = "Theme";
        }

        public static class ModuleClaim
        {
            public const string LeadCreate = "LEAD_CREATE";
            public const string LeadUpdate = "LEAD_UPDATE";
            public const string LeadRead = "LEAD_READ";
            public const string LeadAllEmployeesRead = "LEAD_ALL_EMPLOYEES_READ";
            public const string LeadDelete = "LEAD_DELETE";
            public const string LeadToUnsuccessful = "LEAD_TO_UNSUCCESSFUL";
            public const string LeadToSuccessful = "LEAD_TO_SUCCESSFUL";
            public const string LeadChangeEmployee = "LEAD_CHANGE_EMPLOYEE";
            public const string OpportunityCreate = "OPPORTUNITY_CREATE";
            public const string OpportunityUpdate = "OPPORTUNITY_UPDATE";
            public const string OpportunityRead = "OPPORTUNITY_READ";
            public const string OpportunityAllEmployeeRead = "OPPORTUNITY_ALL_EMPLOYEE_READ";
            public const string OpportunityDelete = "OPPORTUNITY_DELETE";
            public const string OpportunityToUnsuccessful = "OPPORTUNITY_TO_UNSUCCESSFUL";
            public const string OpportunityToSuccessful = "OPPORTUNITY_TO_SUCCESSFUL";
            public const string OpportunityChangeEmployee = "OPPORTUNITY_CHANGE_EMPLOYEE";
            public const string CategoryCreate = "CATEGORY_CREATE";
            public const string CategoryUpdate = "CATEGORY_UPDATE";
            public const string CategoryRead = "CATEGORY_READ";
            public const string CategoryDelete = "CATEGORY_DELETE";
            public const string ProcessCreate = "PROCESS_CREATE";
            public const string ProcessUpdate = "PROCESS_UPDATE";
            public const string ProcessRead = "PROCESS_READ";
            public const string ProcessDelete = "PROCESS_DELETE";
            public const string EmployeeCreate = "EMPLOYEE_CREATE";
            public const string EmployeeUpdate = "EMPLOYEE_UPDATE";
            public const string EmployeeRead = "EMPLOYEE_READ";
            public const string EmployeeDelete = "EMPLOYEE_DELETE";
            public const string EmployeeUpdateRole = "EMPLOYEE_UPDATE_ROLE";
            public const string ProductCreate = "PRODUCT_CREATE";
            public const string ProductUpdate = "PRODUCT_UPDATE";
            public const string ProductRead = "PRODUCT_READ";
            public const string ProductDelete = "PRODUCT_DELETE";
            public const string ProductHeaderCreate = "PRODUCT_HEADER_CREATE";
            public const string ProductHeaderUpdate = "PRODUCT_HEADER_UPDATE";
            public const string ProductHeaderRead = "PRODUCT_HEADER_READ";
            public const string ProductHeaderDelete = "PRODUCT_HEADER_DELETE";
            public const string ContactCreate = "CONTACT_CREATE";
            public const string ContactUpdate = "CONTACT_UPDATE";
            public const string ContactRead = "CONTACT_READ";
            public const string ContactDelete = "CONTACT_DELETE";
            public const string NoteAccess = "NOTE_ACCESS";
            public const string CalendarAccess = "CALENDAR_ACCESS";
            public const string CompanyRead = "COMPANY_READ";
            public const string CompanyUpdate = "COMPANY_UPDATE";
            public const string BranchCreate = "BRANCH_CREATE";
            public const string BranchUpdate = "BRANCH_UPDATE";
            public const string BranchRead = "BRANCH_READ";
            public const string BranchDelete = "BRANCH_DELETE";
            public const string BankAccountCreate = "BANK_ACCOUNT_CREATE";
            public const string BankAccountUpdate = "BANK_ACCOUNT_UPDATE";
            public const string BankAccountRead = "BANK_ACCOUNT_READ";
            public const string BankAccountDelete = "BANK_ACCOUNT_DELETE";
        }

        public static class SystemRole
        {
            public const string SystemAdmin = "SystemAdmin";
            public const string SuperAdmin = "SuperAdmin";
        }

        public static class ApiMessage
        {
            public const string InformationReceivedSuccessfully = "اطلاعات با موفقیت دریافت شد";
            public const string InformationSuccessfullyRegistered = "اطلاعات با موفقیت ثبت شد";
            public const string ErrorInTheApplicationProcess = "اشکال در روند برنامه";
            public const string UserNotFound = "کاربر یافت نشد";
            public const string YouDoNotHaveTheRequiredAccess = "شما دسترسی لازم را ندارید";
            public const string TheSubmittedFileFormatIsNotAcceptable = "فرمت فایل ارسالی قابل قبول نیست";
            public const string InformationUpdated = "بروزرسانی اطلاعات انجام شد";
            public const string InformationNotFound = "اطلاعات یافت نشد";
            public const string YourRequestWasSuccessful = "درخواست شما با موفقیت انجام شد";
            public const string PackageSuccessfullyReceivedAndSaved = "بسته با موفقیت دریافت و ذخیره شد";
            public const string FileSuccessfullyUploaded = "فایل با موفقیت آپلود شد";
            public const string TheInformationIsIncorrect = "اطلاعات نادرست است";
            public const string YourRequestIsNotApplicable = "درخواست شما غیر قابل اجرا می باشد";
        }

        public static class SendMessageType
        {
            public const string Person = "Person";
            public const string Opportunity = "Opportunity";
            public const string Product = "Product";
            public const string ProductPriceHeader = "ProductPriceHeader";
        }

        public static class SendMessageAction
        {
            public const string Insert = "Insert";
            public const string Update = "Update";
            public const string Delete = "Delete";
            public const string Read = "Read";
        }
    }
}