import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { APIService } from 'src/app/API/api.service';

export class PacientRelation {
  constructor(
    public NmidMedicotra: Number,
    public Dseps: string,
    public Dsarl: string,
    public Cdusuario: string,
    public Dscondicion: string) { }
}

@Component({
  selector: 'app-Person',
  templateUrl: './Person.component.html',
  styleUrls: ['./Person.component.css']
})
export class PersonComponent implements OnInit {
  form: any;
  personType: any;
  genders: any;
  people: any;
  medical: any;
  PacienteNmidMedicotraNavigations: any;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private API: APIService) {
  }
  get f() { return this.form.controls; }
  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    this.form.value.PacienteNmidMedicotraNavigations = new Array;
    this.form.value.PacienteNmidMedicotraNavigations.push(new PacientRelation
      (
        this.form.value.NmidMedicotra != '' ? this.form.value.NmidMedicotra : 0,
        this.form.value.Dseps,
        this.form.value.Dsarl,
        this.form.value.Cdusuario,
        this.form.value.Dscondicion,
      ));
    console.log(this.form.value)
    this.API.sendFormNewPerson(this.form.value).subscribe(response => {
      alert(response);
      for (var name in this.form.controls) {
        (this.form.controls[name]).updateValue('');
        this.form.controls[name].setErrors(null);
      }
    });
  }

  onChange(personDocument: any) {
    var showInfo = this.people.filter((x: any) => x.cddocumento == personDocument.value)[0];
    this.form = this.uploadData(showInfo != null ? showInfo : new Object());
  }

  uploadData(showInfo: any) {
    var patientCorrect = showInfo.pacienteNmidPersonaNavigations != null && showInfo.pacienteNmidPersonaNavigations.length > 0;
    return this.formBuilder.group({
      Cddocumento: [showInfo.cddocumento != null ? showInfo.cddocumento : '', Validators.required],
      Dsnombres: [showInfo.dsnombres != null ? showInfo.dsnombres : '', Validators.required],
      Dsapellidos: [showInfo.dsapellidos != null ? showInfo.dsapellidos : '', Validators.required],
      Fenacimiento: [showInfo.fenacimiento != null ? showInfo.fenacimiento : '', Validators.required],
      Cdtipo: [showInfo.cdtipo != null ? showInfo.cdtipo : '', Validators.required],
      Cdgenero: [showInfo.cdgenero != null ? showInfo.cdgenero : '', Validators.required],
      Dsdireccion: [showInfo.dsdireccion != null ? showInfo.dsdireccion : '', Validators.required],
      CdtelfonoFijo: [showInfo.cdtelfonoFijo != null ? showInfo.cdtelfonoFijo : '', Validators.required],
      CdtelefonoMovil: [showInfo.cdtelefonoMovil != null ? showInfo.cdtelefonoMovil : '', Validators.required],
      DsEmail: [showInfo.dsEmail != null ? showInfo.dsEmail : '', [Validators.required, Validators.email]],
      NmidMedicotra: [patientCorrect ? showInfo.pacienteNmidPersonaNavigations[0].nmidMedicotra : '', []],
      Dseps: [patientCorrect ? showInfo.pacienteNmidPersonaNavigations[0].dseps : '', []],
      Dsarl: [patientCorrect ? showInfo.pacienteNmidPersonaNavigations[0].dsarl : '', []],
      Cdusuario: [patientCorrect ? showInfo.pacienteNmidPersonaNavigations[0].cdusuario : '', []],
      Dscondicion: [patientCorrect ? showInfo.pacienteNmidPersonaNavigations[0].dscondicion : '', []]
    });
  }

  ngOnInit() {
    this.form = this.uploadData(new Object());
    this.API.getAllGender().subscribe(
      response => {
        this.genders = response.response;
      }
    );
    this.API.getAllPersonType().subscribe(
      response => {
        this.personType = response.response;
      }
    );
    this.API.getAll().subscribe(
      response => {
        this.people = response.response;
      }
    );
    this.API.getAllMedical().subscribe(
      response => {
        this.medical = response.response;
      }
    );
  }
}
