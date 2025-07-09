<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Agenda extends Model
{
    protected $primaryKey = 'id_agenda';
    protected $fillable = [
        'date_planifie', 'titre', 'heure_debut', 'heure_fin',
        'creneau', 'lieu', 'statut', 'id_medecin'
    ];

    public function medecin()
    {
        return $this->belongsTo(Medecin::class, 'id_medecin');
    }

    public function rendezvous()
    {
        return $this->hasMany(RendezVous::class, 'id_agenda');
    }
}
