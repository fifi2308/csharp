<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class RendezVous extends Model
{
    protected $primaryKey = 'id_rv';

    public function soin()
    {
        return $this->belongsTo(Soin::class, 'id_soin');
    }

    public function patient()
    {
        return $this->belongsTo(Patient::class, 'id_patient');
    }

    public function medecin()
    {
        return $this->belongsTo(Medecin::class, 'id_medecin');
    }

    public function moyenPaiement()
    {
        return $this->belongsTo(MoyenPaiement::class, 'id_moyen_paiement');
    }

    public function agenda()
    {
        return $this->belongsTo(Agenda::class, 'id_agenda');
    }
}
