import { Student } from "./Student";

export interface ExperienceLevel {
    experienceLevelId: number;
    name: string;
    students: Student[];
}