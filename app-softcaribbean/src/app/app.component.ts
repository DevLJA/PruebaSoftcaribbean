import { Component, OnInit } from '@angular/core';
import { APIService } from './API/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'app-softcaribbean';
  post = new Object();
  titulosColumnas = ['código de usuario', 'código de post', 'titulo', 'descripción'];
  constructor(private service: APIService) { }

  ngOnInit() {
    //this.service.retornar()
     // .subscribe(result => this.post = result)
  }
}
