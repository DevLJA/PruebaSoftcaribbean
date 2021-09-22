import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  constructor(private httpClient: HttpClient) {
  }
  getAll() {
    return this.httpClient.get<any>('https://localhost:44353/Person/GetAll');
  }
  getAllMedical() {
    return this.httpClient.get<any>('https://localhost:44353/Person/GetAllMedical');
  }
  getAllPatients() {
    return this.httpClient.get<any>('https://localhost:44353/Patient/GetAllPatients');
  }
  getAllPersonType() {
    return this.httpClient.get<any>('https://localhost:44353/Types/GetPersonType');
  }
  getAllGender() {
    return this.httpClient.get<any>('https://localhost:44353/Types/GetGenders');
  }

  sendFormNewPerson(newPerson: any) {
    return this.httpClient.post<any>('https://localhost:44353/Person/CreateNewPerson', newPerson);
  }
}
