import { Student } from "./Student";

export interface EmploymentStatus {
    employmentStatusId: number;
    name: string;
    students: Student[];
}