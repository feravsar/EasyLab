

import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import * as ace from 'ace-builds';
import 'ace-builds/src-noconflict/theme-github';
import 'ace-builds/src-noconflict/theme-twilight'
import 'ace-builds/src-noconflict/mode-java';
import 'ace-builds/src-noconflict/ext-language_tools';
import { StudentService } from '@app/services/student.service';
import { ActivatedRoute } from '@angular/router';

const GITHUB_THEME = 'ace/theme/github';
const TWILIGHT_THEME = 'ace/theme/twilight';
const JAVA_LANG = 'ace/mode/java';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  @ViewChild('codeEditor', { static: true }) codeEditorElmRef: ElementRef;
  private codeEditor: ace.Ace.Editor;

  @ViewChild('resultEditor', { static: true }) resultEditorElmRef: ElementRef;
  private resultEditor: ace.Ace.Editor;

  private projectId;

  constructor(private studentService: StudentService, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.projectId = params['id'];
    });

    this.studentService.getFileContent(this.projectId, "App.java")
      .subscribe(data => {
        this.codeEditor.setValue(data.fileContent);
      })


    ace.require('ace/ext/language_tools');

    const codeElement = this.codeEditorElmRef.nativeElement;


    this.codeEditor = ace.edit(codeElement, this.getEditorOptions());
    this.codeEditor.setTheme(GITHUB_THEME);
    this.codeEditor.getSession().setMode(JAVA_LANG);
    this.codeEditor.setShowFoldWidgets(true); // for the scope fold feature


    const resultElement = this.resultEditorElmRef.nativeElement;
    const resultEditorOptions: Partial<ace.Ace.EditorOptions> = {
      highlightActiveLine: true,
      minLines: 15,
      maxPixelHeight: 300,
      maxLines: Infinity,
      fontSize: 15,
      readOnly: true
    };

    this.resultEditor = ace.edit(resultElement, resultEditorOptions);
    this.resultEditor.setTheme(TWILIGHT_THEME);
    this.resultEditor.getSession().setMode(JAVA_LANG);
    this.resultEditor.setShowFoldWidgets(true); // for the scope fold feature





  }

  private getEditorOptions(): Partial<ace.Ace.EditorOptions> & { enableBasicAutocompletion?: boolean; } {
    const basicEditorOptions: Partial<ace.Ace.EditorOptions> = {
      highlightActiveLine: true,
      minLines: 25,
      maxPixelHeight: 300,
      fontSize: 15,
      maxLines: Infinity,
    };

    const extraEditorOptions = {
      enableBasicAutocompletion: true
    };
    const margedOptions = Object.assign(basicEditorOptions, extraEditorOptions);
    return margedOptions;
  }


  save(){

    console.log("value",this.codeEditor.getValue());

    return this.studentService.updateDocument(
      {
        projectId : this.projectId,
        fileName:"App.java",
        fileContent:this.codeEditor.getValue()
      }
    );
  }

  build() {
    this.save().subscribe(data=>{
      console.log(data);
      this.studentService.buildProject({ projectId: this.projectId })
      .subscribe(data => {
        if (data.message == "")
          this.resultEditor.setValue("Build Successfull")
        else
          this.resultEditor.setValue(data.message);
      },
        err => {
          console.log(err)
        })
    },
    err=>{
      console.log(err);
    })
    
  }

  run() {
    this.studentService.runProject({ projectId: this.projectId })
      .subscribe(data => {
        if (data.bashResponse.success) {
          this.resultEditor.setValue(data.bashResponse.output);
        }
        else {
          this.resultEditor.setValue(data.bashResponse.error);
        }
      },
        err => {
          console.log(err)
        })
  }


}
