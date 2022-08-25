import { Course } from "./Course";
import { Student } from "./Student";

export interface Industry {
    industryId: number;
    name: string;
    students: Student[];
    courses: Course[];
}