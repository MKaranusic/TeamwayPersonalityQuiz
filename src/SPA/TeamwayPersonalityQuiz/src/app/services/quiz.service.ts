import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Question } from '../models/question';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  private _endpoint = "https://localhost:7062/api/question";

  constructor(private _http: HttpClient) { }

  getQuestions(): Observable<Question[]> {
    return this._http.get<Question[]>(`${this._endpoint}`);
  }

  getQuizResult(score: string): Observable<string> {
    return this._http.get<string>(`${this._endpoint}/${score}`);
  }
}
