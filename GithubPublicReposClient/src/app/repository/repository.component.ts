import { Component, Input, OnInit } from '@angular/core';
import { IRepositoryDetail } from '../shared/models/repositoryDetail';

@Component({
  selector: 'app-repository',
  templateUrl: './repository.component.html',
  styleUrls: ['./repository.component.css']
})
export class RepositoryComponent implements OnInit {
  // used 'Definite Assignment Assertion' "!" to tell typescript that this variable will have a value at runtime
  @Input() repositoryDetail!: IRepositoryDetail;

  constructor() {}

  ngOnInit(): void {
  }

}
