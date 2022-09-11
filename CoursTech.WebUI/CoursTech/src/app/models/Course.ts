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
    image: File | null;
    instructorId: string;
    instructor: Instructor | null;
    industryId: number;
    industry: Industry | null;
    enrollments: Enrollment[] | null;
}