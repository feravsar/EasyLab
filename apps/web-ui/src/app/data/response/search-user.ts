import { User } from '../schema/user';
import {BaseResponse} from './base-response';

export class SearchUser extends BaseResponse {
    public users:User[];
}
