<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use App\Models\Utilisateur;
use App\Models\Personne;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Validator;

class AuthController extends Controller
{
    public function register(Request $request)
    {
        $validator = Validator::make($request->all(), [
            'nom_prenom' => 'required',
            'adresse' => 'required',
            'email' => 'required|email|unique:personnes,email',
            'tel' => 'required',
            'identifiant' => 'required|unique:utilisateurs,identifiant',
            'motdepasse' => 'required|min:6',
            'id_role' => 'required|exists:roles,id'
        ]);

        if ($validator->fails()) {
            return response()->json($validator->errors(), 422);
        }

        $personne = Personne::create([
            'nom_prenom' => $request->nom_prenom,
            'adresse' => $request->adresse,
            'email' => $request->email,
            'tel' => $request->tel,
        ]);

        $utilisateur = Utilisateur::create([
    'identifiant' => $request->identifiant,
    'motdepasse' => bcrypt($request->motdepasse),
    'id_role' => $request->id_role,
    'id_personne' => $personne->id,
]);

        $token = $utilisateur->createToken('auth_token')->plainTextToken;

        return response()->json(['access_token' => $token, 'token_type' => 'Bearer']);
    }

    public function login(Request $request)
    {
        $utilisateur = Utilisateur::where('identifiant', $request->identifiant)->first();

if (!$utilisateur || !Hash::check($request->motdepasse, $utilisateur->motdepasse)) {
    return response()->json(['message' => 'Identifiant ou mot de passe incorrect'], 401);
}


        $token = $utilisateur->createToken('auth_token')->plainTextToken;

        return response()->json(['access_token' => $token, 'token_type' => 'Bearer']);
    }
}
