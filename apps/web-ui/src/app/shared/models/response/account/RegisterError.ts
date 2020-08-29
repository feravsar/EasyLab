import {CustomError} from './../../CustomError';

export class RegisterError{
    public Name: string[];
    public Surname: string[];
    public Email: string[];
    public Password: string[];
    public ConfirmPassword: string[];
    public CustomErrors: CustomError[];
}