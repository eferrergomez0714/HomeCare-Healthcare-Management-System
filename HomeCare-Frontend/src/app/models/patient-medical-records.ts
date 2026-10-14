import { MedicalRecord } from './medical-record';

export interface PatientMedicalRecords {
    ssn: string;
    medicalRecords: MedicalRecord[];
}
