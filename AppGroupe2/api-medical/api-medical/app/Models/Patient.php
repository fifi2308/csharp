<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Patient extends Model
{
    protected $fillable = ['groupe_sanguin', 'poids', 'taille', 'date_naissance', 'id_personne'];

    public function personne()
    {
        return $this->belongsTo(Personne::class, 'id_personne');
    }
}

