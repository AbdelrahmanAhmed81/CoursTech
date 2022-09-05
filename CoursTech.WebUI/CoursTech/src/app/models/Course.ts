import { Enrollment } from "./Enrollment";
import { Industry } from "./Industry";
import { Instructor } from "./Instructor";

export interface Course {
    courseId: string;
    title: string;
    duration: string;
    date: string;
    description: string;
    imageName: string;
    instructorId: string;
    instructor?: Instructor;
    industryId: number;
    industry?: Industry;
    enrollments?: Enrollment[];
}