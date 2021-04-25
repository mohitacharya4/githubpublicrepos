import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GithubService } from '../github.service';
import { IRepositoryDetail } from '../shared/models/repositoryDetail';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  loading = false;
  repositoryDetails: IRepositoryDetail[] = [];

  constructor(private githubService: GithubService) {}

  ngOnInit(): void {}

  getUserRepos(userDetails: NgForm) {
    this.loading = true;
    const username: string = userDetails.value.username;

    this.githubService.getUserRepositories(username).subscribe(
      (response) => {
        this.loading = false;
        this.repositoryDetails = response;
      },
      (error) => {
        this.loading = false;
        alert('User not found');
      }
    );
  }
}
