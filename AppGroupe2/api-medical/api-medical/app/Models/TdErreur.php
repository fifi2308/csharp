<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
class TdErreur extends Model
{
    protected $primaryKey = 'id_erreur';

    protected $fillable = ['date_erreur', 'titre_erreur', 'description_erreur'];
}

