import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})

/* life cycle
* component loads -> construct component -> ngOnInit -> call method
*/
export class ValueComponent implements OnInit {
  values: any;

  // ctor: use a HttpClient service name it as parameter "http"
  constructor(private http: HttpClient) {
  }
  ngOnInit() {
    this.getValue();
  }
  // call method getValue
  getValue() {
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    }
    );
  }
}
