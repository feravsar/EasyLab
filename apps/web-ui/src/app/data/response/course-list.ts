import { Course } from "../schema/course";
import { BaseResponse } from './base-response';

export class CourseList extends BaseResponse {
    public courses: Course[];
}
