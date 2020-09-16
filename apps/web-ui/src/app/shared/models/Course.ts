export class Course{
    
    constructor(courseId:number, courseName:string, courseDescription:string){
        this.courseId = courseId;
        this.courseName = courseName;
        this.courseDescription= courseDescription;
    }

    public courseId: number;
    public courseName: string;
    public courseDescription: string;
}