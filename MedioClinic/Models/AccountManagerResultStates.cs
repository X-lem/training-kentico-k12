﻿namespace MedioClinic.Models
{
    public enum RegisterResultState
    {
        UserNotCreated,
        TokenNotCreated,
        EmailSent,
        SignedIn,
        NotSignedIn
    }

    public enum ConfirmUserResultState
    {
        EmailNotConfirmed,
        AvatarNotCreated,
        UserConfirmed
    }

    public enum SignInResultState
    {
        UserNotFound,
        EmailNotConfirmed,
        SignedIn,
        NotSignedIn
    }

    public enum SignOutResultState
    {
        SignedOut,
        NotSignedOut
    }

    public enum ForgotPasswordResultState
    {
        UserNotFound,
        EmailNotConfirmed,
        TokenNotCreated,
        EmailSent,
        EmailNotSent
    }

    public enum ResetPasswordResultState
    {
        InvalidToken,
        TokenVerified,
        PasswordNotReset,
        PasswordReset
    }
}