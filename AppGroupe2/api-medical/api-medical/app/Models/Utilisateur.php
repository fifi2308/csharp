<?php

namespace App\Models;

use Illuminate\Foundation\Auth\User as Authenticatable;
use Laravel\Sanctum\HasApiTokens;
use Illuminate\Notifications\Notifiable;

class Utilisateur extends Authenticatable
{
    use HasApiTokens, Notifiable;

    protected $table = 'utilisateurs';

    protected $primaryKey = 'id';

    protected $fillable = [
        'identifiant', 'motdepasse', 'status', 'id_role', 'id_personne',
    ];

    protected $hidden = [
        'motdepasse',
    ];

    public function role()
    {
        return $this->belongsTo(Role::class, 'id_role');
    }
}
