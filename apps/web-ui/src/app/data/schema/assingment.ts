export class Assignment {
    
    constructor(courseId:string,due:Date,author:string,dateCreated:Date,description:string,languageId:string){
        this.courseId = courseId;
        this.due = due;
        this.author = author;
        this.dateCreated = dateCreated;
        this.description = description;
        this.languageId = languageId;
    }

    public courseId: string;
    public due: Date;
    public author: string;
    public dateCreated: Date;
    public description: string;
    public languageId: string;

}