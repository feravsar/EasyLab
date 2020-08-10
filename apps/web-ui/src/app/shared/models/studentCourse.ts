
    export class studentCourse 
    {
        private studentId : number;
        private studentName : string;
        
        private courseId : number;
        private courseName : string;

        constructor(studentId:number, studentName:string,
         courseId:number, courseName:string) 
        {
            this.studentId = studentId;
            this.studentName = studentName;
            this.courseId = courseId;
            this.courseName = courseName;
        }
    }