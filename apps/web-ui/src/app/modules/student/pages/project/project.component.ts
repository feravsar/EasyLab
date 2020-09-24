

import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import * as ace from 'ace-builds';
import 'ace-builds/src-noconflict/theme-github';
import 'ace-builds/src-noconflict/theme-twilight'
import 'ace-builds/src-noconflict/mode-java';
import 'ace-builds/src-noconflict/ext-language_tools';

const GITHUB_THEME = 'ace/theme/github';
const TWILIGHT_THEME = 'ace/theme/twilight';
const JAVA_LANG = 'ace/mode/java';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  @ViewChild('codeEditor',{static: true}) codeEditorElmRef: ElementRef;
  private codeEditor: ace.Ace.Editor;

  @ViewChild('resultEditor',{static: true}) resultEditorElmRef: ElementRef;
  private resultEditor: ace.Ace.Editor;


  constructor() { }

  ngOnInit() {

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
      maxLines: Infinity,
      fontSize:15,
      readOnly:true
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
        fontSize:15,
        maxLines: Infinity,
    };

    const extraEditorOptions = {
        enableBasicAutocompletion: true
    };
    const margedOptions = Object.assign(basicEditorOptions, extraEditorOptions);
    return margedOptions;
}
  

}
