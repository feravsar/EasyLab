import { User } from '../schema/user';
import {BaseResponse} from './base-response';

export class UserList extends BaseResponse {
    public courseUsers:User[];
}
