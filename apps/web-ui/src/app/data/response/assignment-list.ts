import { Assignment } from "../schema/assingment";
import { BaseResponse } from './base-response';

export class AssignmentList extends BaseResponse {
    public assignments: Assignment[];
}
