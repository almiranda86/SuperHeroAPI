/** source/routes/posts.ts */
import express from 'express';
import controller from '../SuperHeroApi/controllers/posts';
import heroController from '../SuperHeroApi/controllers/heroController';
const router = express.Router();

router.get('/get_all_heroes', heroController.getAllHeroes);
router.get('/posts', controller.getPosts);
router.get('/posts/:id', controller.getPost);
router.put('/posts/:id', controller.updatePost);
router.delete('/posts/:id', controller.deletePost);
router.post('/posts', controller.addPost);

export = router;