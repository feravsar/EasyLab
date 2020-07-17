export class Course{
    
    constructor(courseId:number, courseName:string){
        this.courseId = courseId;
        this.courseName = courseName;
    }

    public courseId: number;
    public courseName: string;
}