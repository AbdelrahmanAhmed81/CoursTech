import { Course } from "./Course";

export interface Instructor {
    instructorId: string;
    firstName: string;
    lastName: string;
    bio: string;
    email: string;
    phoneNumber: string;
    photoName: string;
    courses: Course[];
}