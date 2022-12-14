export interface PassowrdValidator {
    "requiredLength": number;
    "requiredUniqueChars": number;
    "requireNonAlphanumeric": boolean;
    "requireLowercase": boolean;
    "requireUppercase": boolean;
    "requireDigit": boolean;
}