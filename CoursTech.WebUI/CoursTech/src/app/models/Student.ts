import { EmploymentStatus } from "./EmploymentStatus";
import { Enrollment } from "./Enrollment";
import { ExperienceLevel } from "./ExperienceLevel";
import { Industry } from "./Industry";

export interface Student {
    studentId: string;
    firstName: string;
    lastName: string;
    bio: string | null;
    email: string;
    birthDate: string | null;
    photoName: string | null;
    industryId: number | null;
    industry: Industry;
    experienceLevelId: number | null;
    experienceLevel: ExperienceLevel;
    employmentStatusId: number | null;
    employmentStatus: EmploymentStatus;
    enrollments: Enrollment[];
}