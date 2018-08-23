using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Constants
{
    public class DataConstants
    {
        public const int NAME_MIN_LENGTH = 2;
        public const int NAME_MAX_LENGTH = 50;

        public const int JOB_TITLE_NAME_MIN_LENGTH = 5;
        public const int JOB_TITLE_NAME_MAX_LENGTH = 80;

        public const int DEPARTMENT_TITLE_MIN_LENGTH = 5;
        public const int DEPARTMENT_TITLE_MAX_LENGTH = 80;

        public const int USERNAME_MIN_LENGTH = 2;
        public const int USERNAME_MAX_LENGTH = 15;

        public const int MIX_BIRTHDATE_YEAR = 1900;
        public const int MAX_BIRTHDATE_YEAR = 2018;

        public const double MIN_SALARY = 500;
        public const double MAX_SALARY = 2000;

        public const int DESCRIPTION_MIN_LENGTH = 10;

        public const int DESCRIPTION_MAX_LENGTH = 5000;

        public const int FILE_LENGTH = 2 * 1024 * 1024;
    }
}
