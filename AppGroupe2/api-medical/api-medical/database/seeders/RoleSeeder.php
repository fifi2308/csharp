<?php

namespace Database\Seeders;
use App\Models\Role;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class RoleSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
   public function run()
{
    Role::insert([
        ['code' => 'ADMIN', 'libelle' => 'Administrateur'],
        ['code' => 'MED', 'libelle' => 'Médecin'],
        ['code' => 'SEC', 'libelle' => 'Secrétaire'],
        ['code' => 'PAT', 'libelle' => 'Patient'],
    ]);
}
}
