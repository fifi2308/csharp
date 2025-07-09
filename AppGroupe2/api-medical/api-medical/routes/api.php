<?php
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

// Contrôleurs API
use App\Http\Controllers\Api\AuthController;
use App\Http\Controllers\Api\UtilisateurController;
use App\Http\Controllers\Api\PatientController;
use App\Http\Controllers\Api\MedecinController;
use App\Http\Controllers\Api\SecretaireController;
use App\Http\Controllers\Api\AgendaController;
use App\Http\Controllers\Api\RendezVousController;
use App\Http\Controllers\Api\SoinController;
use App\Http\Controllers\Api\MoyenPaiementController;
use App\Http\Controllers\Api\RoleController;
use App\Http\Controllers\Api\SpecialiteController;
use App\Http\Controllers\Api\GroupeSanguinController;
use App\Http\Controllers\Api\TdErreurController;

// 📌 Authentification
Route::post('/register', [AuthController::class, 'register']);
Route::post('/login', [AuthController::class, 'login'])->name('login');  // <-- ajout du name ici


    // 🔐 Auth
    Route::post('/logout', [AuthController::class, 'logout']);

    // 👤 Utilisateurs
    Route::apiResource('utilisateurs', UtilisateurController::class);

    // 👨‍⚕️ Médecins, patients, secrétaires
    Route::apiResource('patients', PatientController::class);
    Route::apiResource('medecins', MedecinController::class);
    Route::apiResource('secretaires', SecretaireController::class);

    // 📅 Agendas & Rendez-vous
    Route::apiResource('agendas', AgendaController::class);
    Route::apiResource('rendezvous', RendezVousController::class);

    // 💊 Soins
    Route::apiResource('soins', SoinController::class);

    // 💳 Moyens de paiement
    Route::apiResource('moyenpaiements', MoyenPaiementController::class);

    // ⚙️ Roles, spécialités, groupes sanguins
    Route::apiResource('roles', RoleController::class);
    Route::apiResource('specialites', SpecialiteController::class);
    Route::apiResource('groupesanguins', GroupeSanguinController::class);

    // ❗ Gestion des erreurs
    Route::apiResource('erreurs', TdErreurController::class);

