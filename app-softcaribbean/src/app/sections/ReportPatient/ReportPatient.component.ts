import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/API/api.service';

export class Patient {
  constructor(
    public ID: Number,
    public Documento: string,
    public Nombre: string,
    public Genero: string,
    public Tipo: string,
    public Telefono: string,
    public Email: string,
    public EPS: string,
    public ARL: string,
    public IDMedico: string,
    public Condicion: string) { }
}

@Component({
  selector: 'app-ReportPatient',
  templateUrl: './ReportPatient.component.html',
  styleUrls: ['./ReportPatient.component.css']
})
export class ReportPatientComponent implements OnInit {
  patients: any[];
  Titles: any;
  objectKeys = Object.keys;
  constructor(private API: APIService) {
    this.patients= new Array;
  }

  ngOnInit() {
    this.API.getAllPatients().subscribe(
      response => {
        response.response.forEach((element: any) => {
          this.patients.push(new Patient(element.nmid, 
            element.cddocumento,
            `${element.dsnombres} ${element.dsapellidos}`, 
            element.cdgeneroNavigation.descripcion,
            element.cdtipoNavigation.descripcion, 
            element.cdtelefonoMovil, 
            element.dsEmail, 
            element.pacienteNmidPersonaNavigations[0].dseps,
            element.pacienteNmidPersonaNavigations[0].dsarl,
            element.pacienteNmidPersonaNavigations[0].nmidMedicotra,
            element.pacienteNmidPersonaNavigations[0].dscondicion));
        });
        this.Titles =  this.objectKeys(this.patients[0]);
      }
    );
  }
}
