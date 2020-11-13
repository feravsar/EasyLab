export class Course {

    constructor(id:string,name:string,description:string,dateCreated:Date,studentsEnrolled:number){
        this.id = id;
        this.name = name;
        this.description = description;
        this.dateCreated = dateCreated;
        this.studentsEnrolled = studentsEnrolled;
    }

    public id: string;
    public name: string;
    public description: string;
    public dateCreated: Date;
    public studentsEnrolled: number;
}
