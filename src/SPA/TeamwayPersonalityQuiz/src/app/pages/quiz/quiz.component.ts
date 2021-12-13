import { Component, OnInit } from '@angular/core';
import { QuizService } from 'src/app/services/quiz.service';
import { Observable } from 'rxjs';
import { Question } from 'src/app/models/question';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent implements OnInit {
  questions$!: Observable<Question[]>;
  dynamicForm!: FormGroup;
  totalScore = 0;
  personality!: string;
  displayScore = false;

  constructor(private quizService: QuizService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.dynamicForm = this.formBuilder.group({
      questions: new FormArray([])
    });

    this.questions$ = this.quizService.getQuestions();
    this.quizService.getQuestions().subscribe(x => {
      for (let i = 0; i < x.length; i++) {
        this.questionsFormArray.push(this.formBuilder.group({
          answer: ['', Validators.required]
        }));
      }
    });
  }

  get dynForm() { return this.dynamicForm.controls; }
  get questionsFormArray() { return this.dynForm['questions'] as FormArray; }

  onSubmit() {
    if (this.dynamicForm.invalid)
      return;

    this.questionsFormArray.controls.forEach(element => {
      this.totalScore += element.value["answer"]
    });

    this.quizService.getQuizResult(this.totalScore).subscribe(x => {
      this.personality = x;
      this.displayScore = true;
    });
  }
}
