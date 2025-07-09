<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Soin extends Model
{
    protected $fillable = ['nom_soin', 'libelle', 'cout'];
}
