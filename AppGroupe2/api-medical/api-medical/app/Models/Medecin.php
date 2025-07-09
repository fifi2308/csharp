<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Medecin extends Model
{
    public function specialite()
    {
        return $this->belongsTo(Specialite::class, 'id_specialite');
    }

    public function utilisateur()
    {
        return $this->belongsTo(Utilisateur::class, 'id_utilisateur');
    }

    public function agendas()
    {
        return $this->hasMany(Agenda::class, 'id_medecin');
    }
}

