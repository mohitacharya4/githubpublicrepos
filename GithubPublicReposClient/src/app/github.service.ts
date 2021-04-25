import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRepositoryDetail } from './shared/models/repositoryDetail';

@Injectable({
  providedIn: 'root'
})
export class GithubService {

  constructor(private http: HttpClient) { }

  getUserRepositories(name: string): Observable<IRepositoryDetail[]> {
    return this.http.post<IRepositoryDetail[]>('https://localhost:5001/api/repository', { username: name });
  }
}
