import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Question } from '../models/question';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  private _endpoint = "https://localhost:7062/api/question";

  constructor(private _http: HttpClient) { }

  getQuestions(): Observable<Question[]> {
    return this._http.get<Question[]>(`${this._endpoint}`);
  }

  getQuizResult(score: number): Observable<string> {
    return this._http.get(`${this._endpoint}/${score}`, { responseType: 'text' });
  }
}
