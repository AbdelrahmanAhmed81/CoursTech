import { Course } from "./Course";
import { Student } from "./Student";

export interface Enrollment {
    studentId: string;
    student: Student;
    courseId: string;
    course: Course;
    date: string;
}