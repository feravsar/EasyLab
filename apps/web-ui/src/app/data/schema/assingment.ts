import { Project } from './project';

export class Assignment {

    public id: string;
    public courseId: string;
    public due: Date;
    public title: string;
    public author: string;
    public dateCreated: Date;
    public description: string;
    public language: string;
    public languageId: number;
    public projectInfo: Project;

}