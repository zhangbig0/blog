using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace blog.CustomerMiddlewares
{
    public class CustomIdentityErrorDescribe:IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
        {
            return new IdentityError{Code =nameof(DefaultError),Description = "发生了未知错误"};
        }

        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError{Code = nameof(ConcurrencyFailure), Description = "乐观并发失败"};
        }

        public override IdentityError PasswordMismatch()
        {
            return base.PasswordMismatch();
        }

        public override IdentityError InvalidToken()
        {
            return base.InvalidToken();
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return base.RecoveryCodeRedemptionFailed();
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return base.LoginAlreadyAssociated();
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return base.InvalidUserName(userName);
        }

        public override IdentityError InvalidEmail(string email)
        {
            return base.InvalidEmail(email);
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return base.DuplicateUserName(userName);
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return base.DuplicateEmail(email);
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return base.InvalidRoleName(role);
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return base.DuplicateRoleName(role);
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return base.UserAlreadyHasPassword();
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return base.UserLockoutNotEnabled();
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return base.UserAlreadyInRole(role);
        }

        public override IdentityError UserNotInRole(string role)
        {
            return base.UserNotInRole(role);
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return base.PasswordTooShort(length);
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return base.PasswordRequiresUniqueChars(uniqueChars);
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return base.PasswordRequiresNonAlphanumeric();
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return base.PasswordRequiresDigit();
        }

        public override IdentityError PasswordRequiresLower()
        {
            return base.PasswordRequiresLower();
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return base.PasswordRequiresUpper();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
